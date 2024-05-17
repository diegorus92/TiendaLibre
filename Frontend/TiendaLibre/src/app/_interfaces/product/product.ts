export interface ProductImage{
    productImageId: number,
    productImageName: string,
    dataImage: string
}

export interface ProductInfo{
    productId: number,
    productName: string,
    productCategory: string,
    productBrand: string,
    productModel: string,
    price: number,
    stockQty: number,
    userSellerId: number,
    productImages: ProductImage[]
}

