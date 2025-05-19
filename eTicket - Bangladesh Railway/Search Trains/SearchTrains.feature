Feature: SearchTrains


@SearchTrains
@DataSource:../TestData/TrainBook.xlsx
Scenario: Trains Search Test
	Given Select From Station "<FromStation>"
	When Select To Station "<ToStation>"
	And Select Date of Journey "<Date>"
	And Choose Class "<Class>"
	And Click on Search Trains
	Then Verify Search Result