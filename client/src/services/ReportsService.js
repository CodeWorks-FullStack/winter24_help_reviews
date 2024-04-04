import { AppState } from "../AppState.js"
import { Report } from "../models/Report.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ReportsService {
  async createReport(reportData) {
    const res = await api.post('api/reports', reportData)
    logger.log('CREATED REPORT', res.data)
  }
  async getReportsByRestaurantId(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS', res.data)
    AppState.reports = res.data.map(pojo => new Report(pojo))
  }

}

export const reportsService = new ReportsService()