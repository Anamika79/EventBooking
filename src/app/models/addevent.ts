export interface AddEvent {
    venueName: string;
    locationID: number;
    categoryID: number;
    userID: number;
    eventName: string;
    eventDescription: string;
    eventStartDate: string;
    eventEndDate: string;
    totalPlatinumSeats: number;
    totalGoldSeats: number;
    totalSilverSeats: number;
    platinumSeatPrice: number;
    goldSeatPrice: number;
    silverSeatPrice: number;
  }