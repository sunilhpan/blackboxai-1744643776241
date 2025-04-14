class PurchaseOrder:
    def __init__(self):
        self.orders = {}
        self.next_order_id = 1
    
    def create_order(self, supplier, items, quantity):
        """Create new purchase order"""
        order_id = f"PO-{self.next_order_id}"
        self.orders[order_id] = {
            'supplier': supplier,
            'items': items,
            'status': 'pending'
        }
        self.next_order_id += 1
        return order_id
    
    def update_order_status(self, order_id, status):
        """Update order status (pending/fulfilled/cancelled)"""
        if order_id in self.orders:
            self.orders[order_id]['status'] = status
    
    def get_orders(self):
        """Return all purchase orders"""
        return self.orders
    
