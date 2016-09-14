#define WR 0x00
#define RD 0x01
#define DEV_NAME "USB2TWI Adapter     "

#include <avr/io.h>
#include "board.h"
#include <util/setbaud.h>
#include <avr/io.h>
#include "libs/bwl_uart.h"
#include "libs/bwl_i2c.h"
#include "libs/spi.h"
#include "libs/bwl_simplserial.h"

void sserial_send_start(){}

void sserial_send_end(){}

void sserial_process_request()
{
	//read single register from slave 
	if (sserial_request.command==1)
	{
		char dev_addr = sserial_request.data[0]*2;
		char regiser  = sserial_request.data[1];
		char resp = 0;
		i2c_start();
		i2c_write_byte(dev_addr|WR); 
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
		char dev_addr = sserial_request.data[0]*2;
		char regiser  = sserial_request.data[1];
		char register_value = sserial_request.data[2];

		i2c_start();
		i2c_write_byte(dev_addr|WR);
		i2c_write_byte(regiser);
		i2c_write_byte(register_value);
		i2c_stop();
		sserial_response.result    = 0;
		sserial_response.datalength= 0;
		sserial_send_response();
	}

	//read array from slave device
	if (sserial_request.command==3){
		char dev_addr = sserial_request.data[0]*2;
		char regiser  = sserial_request.data[1];
		char count = sserial_request.data[2];
		int i = 0;
		i2c_start();
		i2c_write_byte(dev_addr|WR); 
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
	    char i = 0; 
		spi_select();
		for(i=0;i<sserial_request.datalength;i++){
			spi_write(sserial_request.data[i]);
		}
		spi_unselect();
		sserial_response.result    = 0;
		sserial_response.datalength= 0;
		sserial_send_response();

	}

	if(sserial_request.command==5){
		  char i = 0;
		  spi_select();
		  sserial_response.datalength = sserial_request.data[0];
		  spi_read_array(sserial_request.data[0], sserial_response.data);
		  spi_unselect();
		  sserial_response.result    = 0;
		  sserial_send_response();
	}
}

void i2c_init()
{
	setbit	(PORTC,4,1);
	setbit	(PORTC,5,1);
	TWSR = 0x01;
	TWBR = 0x02;
}

int main(void)
{
    spi_init();
    uart_init_withdivider(0, UBRR_VALUE);
	i2c_init();	
   	sserial_find_bootloader();
   	sserial_set_devname(DEV_NAME);
   	while (1)
   	{
	   	sserial_poll_uart(0);
	   	wdt_reset();
   	}
}

