// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "stdafx.h"

class PurchaseOrder
{
public:
    PurchaseOrder(int id);
    ~PurchaseOrder();
public:
    int Id;
    void Print();
};
