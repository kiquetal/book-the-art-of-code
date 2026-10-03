import java.util.Optional;
import java.time.LocalDate;
import java.util.List;

public class NullableDemo {

    // Using a record for simplicity
    public record Customer(String email, LocalDate lastPurchased, boolean hasOptIn, boolean isGoldBuyer) {}

    public static void main(String[] args) {
        // Customer with a purchase date
        Customer c1 = new Customer("active@test.com", LocalDate.now().minusMonths(2), true, false);
        // Customer with NO purchase date (null)
        Customer c2 = new Customer("no-purchase@test.com", null, true, false);
        // Customer with old purchase date
        Customer c3 = new Customer("inactive@test.com", LocalDate.now().minusMonths(8), true, false);

        List<Customer> customers = List.of(c1, c2, c3);

        System.out.println("--- Checking customer activity ---");
        for (Customer customer : customers) {
            // Using Optional.ofNullable to safely handle potentially null lastPurchased
            // If lastPurchased() returns null, Optional.ofNullable returns Optional.empty()
            // .filter() is then not executed or it handles the empty correctly
            boolean isActiveCustomer = Optional.ofNullable(customer.lastPurchased())
                .filter(purchaseDate -> purchaseDate.isAfter(LocalDate.now().minusMonths(6)))
                .isPresent();

            System.out.println("Customer: " + customer.email() + 
                               ", Last Purchased: " + customer.lastPurchased() + 
                               ", Active: " + isActiveCustomer);
        }
    }
}
