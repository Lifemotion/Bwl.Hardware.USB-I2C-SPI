#include <asf.h>
#include "Descriptors.h"
#include "avr/power.h"
#include "avr/wdt.h"
#include "bwl_simplserial.h"
#include "bwl_i2c.h"
#include "spi.h"
#include <util/delay.h>

//#define F_CPU 48000000
#define WR 0xFE
#define RD 0x01
#define DEV_NAME "TWI/SPI Adapter Atmega32U4"

static FILE USBSerialStream;
int16_t recveived_byte;

void SetupHardware(void);
unsigned char uart_received( unsigned char var);
unsigned char uart_get( unsigned char var );
void uart_send(unsigned char var, unsigned char data);
void i2c_init(void);

USB_ClassInfo_CDC_Device_t VirtualSerial_CDC_Interface =
{
	.Config =
	{
		.ControlInterfaceNumber     = INTERFACE_ID_CDC_CCI,
		.DataINEndpoint             =
		{
			.Address                = CDC_TX_EPADDR,
			.Size                   = CDC_TXRX_EPSIZE,
			.Banks                  = 1,
		},
		.DataOUTEndpoint                =
		{
			.Address                = CDC_RX_EPADDR,
			.Size                   = CDC_TXRX_EPSIZE,
			.Banks                  = 1,
		},
		.NotificationEndpoint           =
		{
			.Address                = CDC_NOTIFICATION_EPADDR,
			.Size                   = CDC_NOTIFICATION_EPSIZE,
			.Banks                  = 1,
		},
	},
};

unsigned char uart_received( unsigned char var)
{
	recveived_byte = CDC_Device_ReceiveByte(&VirtualSerial_CDC_Interface);
	if(recveived_byte<0) return 0;
	return 1;
}

unsigned char uart_get( unsigned char var )
{
	return (unsigned char)recveived_byte;
}

void var_delay_ms(int ms)
{
	Delay_MS(ms);
}

void uart_send(unsigned char var, unsigned char data){
	CDC_Device_SendByte(&VirtualSerial_CDC_Interface, data);
}

void i2c_init(void)
{
	PORTD |= (1<<0)|(1<<1);
	TWSR = 0x00;
	TWBR = 232;
}

void sserial_send_start(){}

void sserial_send_end(){}

void sserial_process_request()
{
	//read single register from slave
	if (sserial_request.command==1)
	{
		char dev_addr = sserial_request.data[0];
		char regiser  = sserial_request.data[1];
		char resp = 0;
	    i2c_start();
		i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_start();
		i2c_write_byte(dev_addr|RD);
		resp = i2c_read_last_byte();
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= 1;
		sserial_response.data[0]   = resp;
		sserial_send_response();
	}

	//write single register to slave
	if (sserial_request.command==2){
		char dev_addr = sserial_request.data[0];
		char regiser  = sserial_request.data[1];
		char register_value = sserial_request.data[2];

		i2c_start();
		i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_write_byte(register_value);
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= 0;
		sserial_send_response();
	}

	//read array from slave device
	if (sserial_request.command==3){
		char dev_addr = sserial_request.data[0];
		char regiser  = sserial_request.data[1];
		char count = sserial_request.data[2];
		int i = 0;
		i2c_start();
		i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_start();
		i2c_write_byte(dev_addr|RD);
		for(i=0;i<(count-1);i++){
			sserial_response.data[i]   =  i2c_read_byte();
		}
		sserial_response.data[count-1] =  i2c_read_last_byte();
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= count;
		sserial_send_response();
	}

	if(sserial_request.command==4){
		byte i = 0;
		sserial_response.datalength = sserial_request.datalength;
		spi_select();
		for(i=0;i<sserial_request.datalength;i++){
			sserial_response.data[i] = spi_read(sserial_request.data[i]);
			//spi_read(sserial_request.data[i]);
			//sserial_response.data[i] = sserial_request.data[i];
		}
		spi_unselect();
		sserial_response.result = 0;
		sserial_send_response();

	}

	if(sserial_request.command==5){
		spi_select();
		sserial_response.datalength = sserial_request.data[0];
		spi_read_array(sserial_request.data[0], sserial_response.data);
		spi_unselect();
		sserial_response.result    = 0;
		sserial_send_response();
	}
}

int main (void)
{
	board_init();
	SetupHardware();
	CDC_Device_CreateStream(&VirtualSerial_CDC_Interface, &USBSerialStream);
	GlobalInterruptEnable();
	//user functions
	sserial_set_devname(DEV_NAME);
	i2c_init();
	spi_init();
	while(1){
		sserial_poll_uart(0);		
		CDC_Device_USBTask(&VirtualSerial_CDC_Interface);
		USB_USBTask();	
	}
}

//configuration for USB 
void SetupHardware(void)
{	
	MCUSR &= ~(1 << WDRF);
	wdt_disable();
	USB_Init();
}


//callback for USB 
void EVENT_USB_Device_Connect(void)
{

}
//callback for USB 
void EVENT_USB_Device_Disconnect(void)
{

}
//callback for USB 
void EVENT_USB_Device_ConfigurationChanged(void)
{
	bool ConfigSuccess = true;
	ConfigSuccess &= CDC_Device_ConfigureEndpoints(&VirtualSerial_CDC_Interface);
}

//callback for USB 
void EVENT_USB_Device_ControlRequest(void)
{
	CDC_Device_ProcessControlRequest(&VirtualSerial_CDC_Interface);
}
//callback for USB 
void EVENT_CDC_Device_ControLineStateChanged(USB_ClassInfo_CDC_Device_t *const CDCInterfaceInfo)
{

}
