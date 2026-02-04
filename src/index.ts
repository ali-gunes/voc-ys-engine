import { fetchRestaurantData } from './scraper.js';
import { extractRestaurantId } from './utils.js';

async function main() {
    const input = process.argv[2];

    if (!input) {
        console.log("Usage: npm start <yemeksepeti-url-or-id>");
        console.log("Example: npm start https://www.yemeksepeti.com/restaurant/s7yc/pasaport-pizza");
        console.log("Example: npm start s7yc");
        process.exit(1);
    }

    const restaurantId = extractRestaurantId(input);

    if (!restaurantId) {
        console.error("Could not extract restaurant ID from input.");
        process.exit(1);
    }

    try {
        const result = await fetchRestaurantData(restaurantId);

        if (result && result.data) {
            console.log("Successfully scraped restaurant data!");
            // Pretty print the result
            console.log(JSON.stringify(result, null, 2));
        } else {
            console.error("Failed to scrape restaurant data.");
        }
    } catch (error) {
        console.error("An error occurred during execution:", error);
    }
}

main();
