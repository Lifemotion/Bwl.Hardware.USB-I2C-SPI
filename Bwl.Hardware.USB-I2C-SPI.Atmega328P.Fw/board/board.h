/*
 * board.h
 *
 * Created: 20.06.2017 11:18:04
 *  Author: gus10
 */ 


#ifndef BOARD_H_
#define BOARD_H_

#define F_CPU     16000000
#define BAUD      9600
#define WR	      0xFE
#define RD        0x01
#define DEV_NAME "TWI/SPI Adapter Atmega328P"

#include <avr/io.h>
#include <util/setbaud.h>
#include <util/delay.h>

#include "../libs/spi.h"
#include "../libs/bwl_uart.h"
#include "../libs/bwl_i2c.h"
#include "../libs/bwl_simplserial.h"

void var_delay_ms(int ms);


#endif /* BOARD_H_ */