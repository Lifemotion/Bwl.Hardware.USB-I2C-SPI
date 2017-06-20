/*
 * Bwl.Hardware.USB-I2C-SPI.Atmega328P.c
 *
 * Created: 20.06.2017 11:16:50
 * Author : gus10
 */ 
#include "board/board.h"


void i2c_init(void)
{
	PORTC |= (1<<4)|(1<<5);
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
		sserial_response.data[0] =i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_start();
		i2c_write_byte(dev_addr|RD);
		resp = i2c_read_last_byte();
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= 2;
		sserial_response.data[1]   = resp;
		sserial_send_response();
	}

	//write single register to slave
	if (sserial_request.command==2){
		char dev_addr = sserial_request.data[0];
		char regiser  = sserial_request.data[1];
		char register_value = sserial_request.data[2];

		i2c_start();
		sserial_response.data[0] = i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_write_byte(register_value);
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= 1;
		sserial_send_response();
	}

	//read array from slave device
	if (sserial_request.command==3){
		char dev_addr = sserial_request.data[0];
		char regiser  = sserial_request.data[1];
		char count = sserial_request.data[2];
		int i = 0;
		i2c_start();
		sserial_response.data[0] = i2c_write_byte(dev_addr&WR);
		i2c_write_byte(regiser);
		i2c_start();
		i2c_write_byte(dev_addr|RD);
		for(i=1;i<count;i++){
			sserial_response.data[i]   =  i2c_read_byte();
		}
		sserial_response.data[count]   =  i2c_read_last_byte();
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= count+1;
		sserial_send_response();
	}

	if(sserial_request.command==4){
		byte i = 0;
		sserial_response.datalength = sserial_request.datalength;
		spi_select();
		for(i=0;i<sserial_request.datalength;i++){
			sserial_response.data[i] = spi_read(sserial_request.data[i]);
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


int main(void)
{   
	sserial_set_devname(DEV_NAME);
	uart_init_withdivider(0, UBRR_VALUE);
	spi_init();
	i2c_init();
    while (1) 
    {
		sserial_poll_uart(0);
    }
}

