```mermaid
     flowchart LR
    A[CartModule]
    B[Common]
    C[Website]
    D[ProductsModule]
    E[PromotionsModule]

    C --> A
    C --> B
    C --> D
    C --> E

    A --> B
    A --> D
    A --> E
```