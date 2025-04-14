from flask import Flask, render_template, request, jsonify
from inventory import Inventory
from purchase_order import PurchaseOrder
from accounting import Accounting
import datetime

app = Flask(__name__)
inventory = Inventory()
purchase_orders = PurchaseOrder()
accounting = Accounting()

@app.route('/')
def home():
    return render_template('index.html',
                         inventory=inventory.get_inventory(),
                         orders=purchase_orders.get_orders(),
                         balance=accounting.get_balance())

@app.route('/api/inventory', methods=['GET', 'POST'])
def manage_inventory():
    if request.method == 'POST':
        data = request.json
        inventory.add_item(data['id'], data['name'], data['quantity'], data['price'])
        return jsonify({'status': 'success'})
    return jsonify(inventory.get_inventory())

@app.route('/api/orders', methods=['GET', 'POST'])
def manage_orders():
    if request.method == 'POST':
        data = request.json
        order_id = purchase_orders.create_order(data['supplier'], data['items'], data['quantity'])
        return jsonify({'order_id': order_id})
    return jsonify(purchase_orders.get_orders())

@app.route('/api/accounting', methods=['GET', 'POST'])
def manage_accounting():
    if request.method == 'POST':
        data = request.json
        accounting.record_transaction(data['amount'], data['description'], data['type'])
        return jsonify({'status': 'success'})
    return jsonify({
        'balance': accounting.get_balance(),
        'transactions': accounting.get_transactions()
    })

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8000, debug=True)
