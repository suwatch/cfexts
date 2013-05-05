
#include "stdafx.h"
#include "PurchaseOrder.h"

PurchaseOrder::PurchaseOrder(int id)
{
    this->Id = id;
}

PurchaseOrder::~PurchaseOrder()
{
}

void PurchaseOrder::Print()
{
    printf("PurchaseOrder: Id=%d\n", this->Id);
}
