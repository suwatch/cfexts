// HelloWorldCPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "windows.h"
#include "PurchaseOrder.h"

void PrintPurchaseOrder(PurchaseOrder *po);

int _tmain(int argc, _TCHAR* argv[])
{
    PurchaseOrder *po = new PurchaseOrder(1234);  
    PrintPurchaseOrder(po);
    delete po;
	return 0;
}

void PrintPurchaseOrder(PurchaseOrder *po)
{
    po->Print();
}