open ArtOfCode.Domain.Chapter1

[<EntryPoint>]
let main argv =
    printfn "============================================="
    printfn " The Art of Code — F# Chapter 1 Companion App"
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

    0 // return an integer exit code
