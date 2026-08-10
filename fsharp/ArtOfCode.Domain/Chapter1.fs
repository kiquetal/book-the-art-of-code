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
