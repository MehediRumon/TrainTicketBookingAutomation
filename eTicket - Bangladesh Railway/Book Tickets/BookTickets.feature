Feature: BookTickets


@BookTickets
@DataSource:../TestData/TrainBook.xlsx
Scenario: Tickets Book Test
	Given Select From Station "<FromStation>"
	When Select To Station "<ToStation>"
	And Select Date of Journey "<Date>"
	And Choose Class "<Class>"
	And Click on Search Trains
	Then Verify Search Result
	When Click Book Now Button for Selected Class "<Class>"
	And Select Available Seats
	When Click on Continue Purchase