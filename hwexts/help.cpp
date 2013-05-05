#include "hwexts.h"

HRESULT CALLBACK help(PDEBUG_CLIENT4 Client, PCSTR args)
{
    dprintf("Help for hwexts.dll\n");
    dprintf("!dumppo <addr>    - dump PurchaseOrder structure for address\n");
    dprintf("!help             - Shows this help\n");
    return S_OK;
}

