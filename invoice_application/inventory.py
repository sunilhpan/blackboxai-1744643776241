class Inventory:
    def __init__(self):
        self.items = {}
    
    def add_item(self, item_id, name, quantity, price):
        """Add new inventory item"""
        self.items[item_id] = {
            'name': name,
            'quantity': quantity,
            'price': price
        }
    
    def update_quantity(self, item_id, quantity_change):
        """Update item quantity"""
        if item_id in self.items:
            self.items[item_id]['quantity'] += quantity_change
    
    def get_inventory(self):
        """Return current inventory"""
        return self.items
