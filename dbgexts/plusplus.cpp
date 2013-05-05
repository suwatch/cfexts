#include "dbgexts.h"

HRESULT _EFN_PlusPlus(PDEBUG_CLIENT4 Client, PULONG Input);

HRESULT CALLBACK plusplus(PDEBUG_CLIENT4 Client, PCSTR args)
{
    ULONG Input;

    Input = (ULONG)GetExpression(args);
    dprintf("dbgext, Before PlusPlus: Input=%d\n", Input);
    _EFN_PlusPlus(Client, &Input);
    dprintf("dbgext, After  PlusPlus: Input=%d\n", Input);

    return S_OK;
}

HRESULT _EFN_PlusPlus(PDEBUG_CLIENT4 Client, PULONG Input)
{
    (*Input)++;
    return S_OK;
}
