import { DatabaseItem } from "./DatabaseItem.js"

export class Restaurant extends DatabaseItem {
  constructor(data) {
    // this.id = data.id
    // this.createdAt = new Date(data.createdAt)
    // this.updatedAt = new Date(data.updatedAt)
    super(data)
    this.name = data.name
    this.imgUrl = data.imgUrl
    this.description = data.description
    this.visits = data.visits
    this.isShutdown = data.isShutdown
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.reportCount = data.reportCount
  }
}