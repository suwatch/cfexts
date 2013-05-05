#include "hwexts.h"
#include "PurchaseOrder.h"
#include "out.hpp"

typedef HRESULT (* FN_PLUSPLUS)(PDEBUG_CLIENT4 Client, PULONG Input);

//HRESULT CALLBACK testext(PDEBUG_CLIENT4 Client, PCSTR args)
//{
//    PDEBUG_CONTROL Control; 
//    FN_PLUSPLUS fnPP = NULL;
//    ULONG Input;
//
//    Input = (ULONG)GetExpression(args);
//
//    // Call function from other extensions
//    Client->QueryInterface(__uuidof(IDebugControl), (void **)&Control);
//    Control->GetExtensionFunction(0, "PlusPlus", (FARPROC*)&fnPP);
//
//    dprintf("hwexts, Before PlusPlus: Input=%d\n", Input);
//    (*fnPP)(Client, &Input);
//    dprintf("hwexts, After  PlusPlus: Input=%d\n", Input);
//
//    Control->Release();
//
//    return S_OK;
//}

HRESULT CALLBACK testext(PDEBUG_CLIENT4 Client, PCSTR args)
{
    PDEBUG_OUTPUT_CALLBACKS prev;
    PDEBUG_CONTROL Control; 
    char cmd[256];

    sprintf(cmd, "!E:\\talk\\demo\\Debug\\dbgexts.plusplus %s", args);

    Client->GetOutputCallbacks(&prev);
    Client->SetOutputCallbacks(&g_OutputCb);
    Client->QueryInterface(__uuidof(IDebugControl), (void **)&Control);
    Control->Execute(DEBUG_OUTCTL_ALL_CLIENTS |
              DEBUG_OUTCTL_OVERRIDE_MASK |
              DEBUG_OUTCTL_NOT_LOGGED,
              cmd, // Command to be executed
              DEBUG_EXECUTE_DEFAULT );
    Control->Release();
    Client->SetOutputCallbacks(prev);

    return S_OK;
}
