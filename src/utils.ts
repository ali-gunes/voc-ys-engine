/**
 * Extracts the restaurant ID from a Yemeksepeti URL or returns the input if it's already an ID.
 * Example URL: https://www.yemeksepeti.com/restaurant/s7yc/pasaport-pizza
 * Example ID: s7yc
 * @param input The URL or ID string
 * @returns The extracted restaurant ID
 */
export function extractRestaurantId(input: string): string {
    if (!input) return "";

    // Updated regex to handle:
    // https://www.yemeksepeti.com/restaurant/y30u/kofteci-yusuf-y30u
    // https://www.yemeksepeti.com/restaurant/y30u/
    // /restaurant/y30u/kofteci-yusuf-y30u
    const urlPattern = /\/restaurant\/([a-z0-9]+)(\/|$)/i;
    const match = input.match(urlPattern);

    if (match && match[1]) {
        return match[1];
    }

    // If it's not a URL, assume it's the ID itself
    // We can add more validation here if needed
    return input.trim();
}
