import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface InventoryItem {
  id: number;
  name: string;
  quantity: number;
  price: number;
}

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent {
  inventoryItems: InventoryItem[] = [
    { id: 1, name: 'Laptop', quantity: 10, price: 999.99 },
    { id: 2, name: 'Mouse', quantity: 25, price: 19.99 },
    { id: 3, name: 'Keyboard', quantity: 15, price: 49.99 }
  ];

  newItem: InventoryItem = { id: 0, name: '', quantity: 0, price: 0 };

  addItem() {
    this.newItem.id = this.inventoryItems.length + 1;
    this.inventoryItems.push({...this.newItem});
    this.newItem = { id: 0, name: '', quantity: 0, price: 0 };
  }

  removeItem(id: number) {
    this.inventoryItems = this.inventoryItems.filter(item => item.id !== id);
  }
}
