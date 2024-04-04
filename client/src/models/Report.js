import { DatabaseItem } from "./DatabaseItem.js";

export class Report extends DatabaseItem {
  constructor(data) {
    super(data)
    this.title = data.title
    this.body = data.body
    this.pictureOfDisgust = data.pictureOfDisgust
    this.restaurantId = data.restaurantId
    this.creatorId = data.creatorId
    this.creator = data.creator
  }
}
