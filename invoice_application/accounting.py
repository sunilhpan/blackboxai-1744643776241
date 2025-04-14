class Accounting:
    def __init__(self):
        self.transactions = []
        self.balance = 0.0
    
    def record_transaction(self, amount, description, transaction_type):
        """Record a financial transaction (income/expense)"""
        transaction = {
            'amount': amount,
            'description': description,
            'type': transaction_type,
            'date': datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        }
        self.transactions.append(transaction)
        
        if transaction_type == 'income':
            self.balance += amount
        else:
            self.balance -= amount
    
    def get_balance(self):
        """Return current account balance"""
        return self.balance
    
    def get_transactions(self):
        """Return all recorded transactions"""
        return self.transactions
