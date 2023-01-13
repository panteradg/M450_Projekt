Feature: FetchData
	Gets the data

Scenario: Price is fetched from Website and saved to Json File
	Given the price is fetched from <Website>
	When the price is saved to the Json File
	Then the product is saved in the Json File with the correct price
	Examples:
	|  Website        |
	| "Digitec"       |
	| "Interdiscount" |
	| "Microspot"     |