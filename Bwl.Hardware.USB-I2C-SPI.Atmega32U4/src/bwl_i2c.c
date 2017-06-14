/*
 * Bwl I2C Lib
 *
 * Author: Igor Koshelev 
 * Licensed: open-source Apache license
 *
 * Version: 01.07.2016
 */ 
#include <avr/io.h>
#include "bwl_i2c.h"

void i2c_wait()
{
	unsigned int i=0;
	while ((!(TWCR & (1 << TWINT))));
}

void i2c_start() {
	unsigned int i=0;
	TWCR = 0;
	TWCR = (1 << TWINT) | (1 << TWSTA) | (1 << TWEN);
	i2c_wait();
	while((TWSR & 0xF8)!= 0x08); 
}

void i2c_write_byte(char byte) {
	TWDR=byte;
	TWCR=(1<<TWINT)|(1<<TWEN);
	unsigned char i=0;
	while ((!(TWCR & (1 << TWINT)))){i++;}
	i=0;
	while(((TWSR & 0xF8) != 0x28)){i++;}
}

char i2c_read_byte() {
	TWCR = (1 << TWINT) | (1 << TWEA) | (1 << TWEN);
	while (!(TWCR & (1<<TWINT))); // Wait till complete TWDR byte transmitted
	unsigned char i=0;
	while((TWSR & 0xF8) != 0x50);
	return TWDR;
}

char i2c_read_last_byte() {
	TWCR=(1<<TWINT)|(1<<TWEN);    // Clear TWI interrupt flag,Enable TWI
	while (!(TWCR & (1<<TWINT))); // Wait till complete TWDR byte transmitted
	unsigned char i=0;
	while((TWSR & 0xF8) != 0x58);
	return TWDR;
}

void i2c_stop() {
	TWCR = (1 << TWINT) | (1 << TWSTO) | (1 << TWEN);
}
