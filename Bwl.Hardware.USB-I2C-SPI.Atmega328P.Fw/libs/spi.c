#include <avr/io.h>
#include "spi.h"
#define spi_wait()	while (!(SPSR & (1 << SPIF)));

void spi_init(void)
{
	DDRB |= ( 1 << 5 ) | ( 1 << 3 ) | ( 1<< 2 );
	DDRB &= ~( 1 << 4 );
	SPCR = ( 1 << SPE ) | ( 1 << MSTR ) | ( 0 << SPR1 )| ( 0 << SPR0 );
	SPSR = 0;     // set double SPI speed for F_osc/8
	PORTB |= ( 1 << 0 );
}


void spi_write(uint8_t data)
{
	SPDR = data;
	while(!(SPSR & (1<<SPIF)));
}

void spi_select()
{
	PORTB &= ~(1 << 2 );
}

void spi_unselect()
{
	PORTB |= (1 << 2 );      
}

uint8_t spi_read(uint8_t data)
{
	SPDR = data;
	while(!(SPSR & (1<<SPIF)));
	return SPDR;
}

void spi_write_array(uint8_t num, uint8_t *data)
{
	while(num--){
		SPDR = *data++;
		while(!(SPSR & (1<<SPIF)));
	}
}

void spi_read_array(uint8_t num, uint8_t *data)
{
	while(num--){
		SPDR = *data;
		while(!(SPSR & (1<<SPIF)));
		*data++ = SPDR;
	}
}

