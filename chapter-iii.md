#### Chapter III- The complex art of simplicity

**Complexity**

The second law of themodynamics states that the total entrophy of an isolated system always increases.
Code is no different. It behaves like a closed system, with entrophy constantly pulling it toward complexity.
Pulling it back toward simplicity takes deliberate steady effort.


Technical debt is the cost of shortcuts taken in code. Sometimes, it's a strategic decision, postponin a clean solution
to meet a deadline or temporarily setting a problem aside.
But like finanncial debit, it accumulates interest over time, making  future change harder, slower, risker and ultimately more expensive.
The longer you wait to address it, the more it compounds and the harder i becomes to safely change the code.

```java
 public void sendEmailRmeainders(List<Customer> customers, String promotionCode){
   for (Customer customer: customers){
   boolean isActiveCustomer = Optional.ofNullable(customer.lastPurchased())
   .filter(purchasedDatat -> purchaseDate.isAfter(LocalDate.now().minusMonth(6))
   .isPresent();


  if (!StringUtils.isBlank(customer.email()) && isActiveCustomer && customer.hasOptIn() || custoer.isGoldBuyer()) {
        String message = buildRemainedrEMail(customer,promoticionCode);
        try {
             emailService.send(customer.email(),message);
        }
        catch(EmailException exception) {
         logger.error(String.format("Failed o send email %s with message",customer.email(),message,exception);
   }
 } 
}

