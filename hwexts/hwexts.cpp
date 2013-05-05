#include "hwexts.h"
#include "PurchaseOrder.h"
#include "out.hpp"

WINDBG_EXTENSION_APIS ExtensionApis;

extern "C" HRESULT CALLBACK DebugExtensionInitialize(PULONG Version, PULONG Flags)
{
    PDEBUG_CLIENT DebugClient;
    PDEBUG_CONTROL DebugControl;

    *Version = DEBUG_EXTENSION_VERSION(1, 0);
    *Flags = 0;

    DebugCreate(__uuidof(IDebugClient), (void **)&DebugClient);

    DebugClient->QueryInterface(__uuidof(IDebugControl), (void **)&DebugControl);
    
    ExtensionApis.nSize = sizeof (ExtensionApis);
    DebugControl->GetWindbgExtensionApis64(&ExtensionApis);

    DebugControl->Release();
    DebugClient->Release();
    return S_OK;
}
