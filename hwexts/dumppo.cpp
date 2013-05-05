#include "hwexts.h"
#include "PurchaseOrder.h"
#include "out.hpp"

//HRESULT CALLBACK dumppo(PDEBUG_CLIENT4 Client, PCSTR args)
//{
//    ULONG cb;
//    ULONG64 Address;
//    ULONG   Buffer[1];
//
//    Address = GetExpression(args);
//    ReadMemory((ULONG_PTR)Address, &Buffer, sizeof(Buffer), &cb);
//    dprintf("Example1, PurchaseOrder: Id=%d\n", Buffer[0]);
//
//    return S_OK;
//}

//HRESULT CALLBACK dumppo(PDEBUG_CLIENT4 Client, PCSTR args)
//{
//    ULONG cb;
//    ULONG64 Address;
//    PurchaseOrder po;
//
//    // ReadMemory to struct
//    Address = GetExpression(args);
//    ReadMemory((ULONG_PTR)Address, &po, sizeof(po), &cb);
//    dprintf("Example2, PurchaseOrder: Id=%d\n", po.Id);
//
//    return S_OK;
//}

HRESULT CALLBACK dumppo(PDEBUG_CLIENT4 Client, PCSTR args)
{
    ULONG cb;
    PurchaseOrder po;
    PDEBUG_DATA_SPACES DataSpaces;
    PDEBUG_CONTROL Control; 
    DEBUG_VALUE DebugValue; 
    ULONG Remainder;

    Client->QueryInterface(__uuidof(IDebugDataSpaces), (void **)&DataSpaces);
    Client->QueryInterface(__uuidof(IDebugControl), (void **)&Control);

    Control->Evaluate(args, DEBUG_VALUE_INT32, &DebugValue, &Remainder);
    DataSpaces->ReadVirtual(DebugValue.I32, &po, sizeof(po), &cb);
    dprintf("Example3, PurchaseOrder: Id=%d\n", po.Id);

    Control->Release();
    DataSpaces->Release();

    return S_OK;
}
