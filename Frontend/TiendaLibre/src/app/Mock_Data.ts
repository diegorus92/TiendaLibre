import { ProductInfo } from "./_interfaces/product/product";

export const mock_products: ProductInfo[] = [
    {
        productId: 1,
        productName: "Article 1",
        productCategory: "Tests",
        productBrand: "Brand",
        productModel: "TsT888",
        price: 20000.50,
        stockQty: 100,
        userSellerId: 233,
        productImages:[{productImageId:0, productImageName:"test1", dataImage:"assets/img/test1.png"},  
                {productImageId:0, productImageName:"test2", dataImage:"assets/img/test2.jpg"},
                {productImageId:0, productImageName:"test3", dataImage:"assets/img/test3.jpg"}]
    },
    {
        productId: 2,
        productName: "Article 2",
        productCategory: "Tests",
        productBrand: "Brand",
        productModel: "TsT888",
        price: 20000.50,
        stockQty: 100,
        userSellerId: 233,
        productImages:[{productImageId:0, productImageName:"test1", dataImage:"assets/img/test1.png"},  
                {productImageId:0, productImageName:"test2", dataImage:"assets/img/test2.jpg"}]
    },

]
