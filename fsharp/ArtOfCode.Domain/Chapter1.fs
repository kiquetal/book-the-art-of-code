namespace ArtOfCode.Domain

module Chapter1 =

    // --- Domain Models ---
    
    type Price = { Amount: decimal }
    
    type PricingDetails = {
        BasePrice: Price
        DiscountedPrice: Price option
    }
    
    type Product = {
        Id: string
        Name: string
        PricingDetails: PricingDetails option
    }

    // --- Domain Errors ---
    
    type PricingError =
        | ProductIsMissing
        | PricingDetailsAreMissing of Product
        | BasePriceIsMissing of Product

    // --- Domain Workflows (Pure Functions) ---
    
    /// Selects the appropriate price from pricing details, favoring the discounted price if present.
    let selectPrice (details: PricingDetails) : Price =
        match details.DiscountedPrice with
        | Some discount -> discount
        | None -> details.BasePrice

    /// Safely gets the final price for a product, returning a Result instead of throwing exceptions.
    let getFinalPrice (product: Product option) : Result<decimal, PricingError> =
        match product with
        | None -> 
            Error ProductIsMissing
        | Some prod ->
            match prod.PricingDetails with
            | None -> 
                Error (PricingDetailsAreMissing prod)
            | Some details ->
                let price = selectPrice details
                Ok price.Amount

    // --- Execution Simulation (Self-Contained Runner) ---
    
    let run () =
        printfn "============================================="
        printfn " Running Chapter 1: The Aesthetics of Code"
        printfn "============================================="
        
        // 1. Create a product with base price only
        let basePriceProduct = {
            Id = "P101"
            Name = "Design Patterns Book"
            PricingDetails = Some {
                BasePrice = { Amount = 49.99m }
                DiscountedPrice = None
            }
        }

        // 2. Create a product with a discounted price
        let discountedProduct = {
            Id = "P102"
            Name = "F# in Action Book"
            PricingDetails = Some {
                BasePrice = { Amount = 59.99m }
                DiscountedPrice = Some { Amount = 39.99m }
            }
        }

        // 3. Create a product missing pricing details completely
        let incompleteProduct = {
            Id = "P103"
            Name = "Draft Software Specifications"
            PricingDetails = None
        }

        // List of test cases to run through our pure pipeline
        let testCases = [
            ("Valid Base Price Product", Some basePriceProduct)
            ("Valid Discounted Product", Some discountedProduct)
            ("Product with Missing Pricing Details", Some incompleteProduct)
            ("None Product (Null representation)", None)
        ]

        printfn "\nRunning Chapter 1 pipeline simulations:"
        printfn "---------------------------------------------"

        for name, productOpt in testCases do
            printfn "Scenario: %s" name
            match getFinalPrice productOpt with
            | Ok amount -> 
                printfn "  => Success! Final Price is: $%M" amount
            | Error error ->
                match error with
                | ProductIsMissing -> 
                    printfn "  => Error: Product is missing/null."
                | PricingDetailsAreMissing prod -> 
                    printfn "  => Error: Pricing details are missing for Product '%s' (ID: %s)." prod.Name prod.Id
                | BasePriceIsMissing prod -> 
                    printfn "  => Error: Base price is missing for Product '%s' (ID: %s)." prod.Name prod.Id
            printfn "---------------------------------------------"
