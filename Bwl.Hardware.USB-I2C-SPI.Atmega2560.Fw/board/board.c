/*
 * board.c
 *
 * Created: 20.06.2017 11:17:54
 *  Author: gus10
 */ 

#include "board.h"

void var_delay_ms(int ms)
{
	for(int i=0;i<ms;i++)_delay_ms(1.0);
}