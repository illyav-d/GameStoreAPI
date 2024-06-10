export interface Order {
    id: number,
    customerID: number,
    totalPriceInEuro: number,
    gameTitles: string[],
    orderDate: string
}