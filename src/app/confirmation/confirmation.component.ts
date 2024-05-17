import { Component } from '@angular/core';
import { jsPDF } from 'jspdf';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent {
  eventDetails: string = "Event: Concert"; // Example event details
  totalTickets: number = 0; // Example total tickets
  totalPrice: number = 0; // Example total price

  constructor(
    private user : UserService,
    private route : Router
  ){}

  logout() {
    this.user.signOut();
    this.route.navigate(['homescreen']);
  }

  generateAndDownloadPDF() {
    // Create a new jsPDF instance
    const doc = new jsPDF();

    // Add event details, total tickets, and total price to the PDF
    const eventName = "Concert"; // Example event name
    const totalTickets = 2; // Example total tickets
    const totalPrice = 200; // Example total price

    // Event Details
    const eventDetails = `Event: ${eventName}\nTickets Booked: ${totalTickets}\nPrice: $${totalPrice}`;
    doc.setFontSize(12);
    doc.text(eventDetails, 10, 20);

    // Ticket Information
    const ticketInfo = [
        { type: "Platinum Ticket", price: 100, quantity: 2 },
        { type: "Gold Ticket", price: 80, quantity: 3 }
        // Add more ticket types if needed
    ];

    let yPos = 50; // Starting Y position for ticket information
    ticketInfo.forEach(ticket => {
        const ticketDetails = `${ticket.type} (Price: $${ticket.price}): ${ticket.quantity} tickets`;
        doc.text(ticketDetails, 10, yPos);
        yPos += 10; // Increment Y position for the next ticket
    });

    // Subtotal
    const subtotal = totalPrice; // Example subtotal
    doc.text(`Subtotal: $${subtotal}`, 10, yPos + 10);

    // Button for confirming and paying
    const buttonWidth = 50; // Adjust button width as needed
    const buttonHeight = 10; // Adjust button height as needed
    const buttonX = (doc.internal.pageSize.width - buttonWidth) / 2; // Center button horizontally
    const buttonY = doc.internal.pageSize.height - 30; // Position button near the bottom
    doc.setFillColor(70, 15, 104); // Purple color
    doc.rect(buttonX, buttonY, buttonWidth, buttonHeight, 'F');
    doc.setTextColor(255);
    doc.setFontSize(12);
    doc.text("Confirm and Pay Now", buttonX + 5, buttonY + 5);

    // Save the PDF
    doc.save('confirmation.pdf');
}
  
}
