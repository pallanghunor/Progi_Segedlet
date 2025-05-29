export interface PaintingModel {
    id: number
    categoryId: number
    categoryName: string
    description: string
    imageUrl: string
    startingPrice: number
    numberOfBids: number
    maxBid?: number
}