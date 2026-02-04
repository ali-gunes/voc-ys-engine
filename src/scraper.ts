import axios from 'axios';
import type { AxiosRequestHeaders } from 'axios';
import * as dotenv from 'dotenv';
import type { YemeksepetiVendorResponse } from './models.js';

dotenv.config();

export async function fetchRestaurantData(restaurantId: string): Promise<YemeksepetiVendorResponse | null> {
    const baseUrl = process.env.INITIAL_PATH || "https://tr.fd-api.com/api/v5/vendors/";
    const queryParams = process.env.QUERY_PATH || "?include=menus,bundles,multiple_discounts,payment_types&language_id=2&opening_type=delivery&basket_currency=TRY";

    const url = `${baseUrl}${restaurantId}${queryParams}`;

    const headers: any = {
        'Accept': process.env.ACCEPT,
        'Accept-Encoding': process.env.ACCEPT_ENCODING,
        'Accept-Language': process.env.ACCEPT_LANGUAGE,
        'Api-Version': process.env.API_VERSION,
        'Connection': process.env.CONNECTION,
        'dps-session-id': process.env.DPS_SESSION_ID,
        'Host': process.env.HOST,
        'Origin': process.env.ORIGIN,
        'perseus-client-id': process.env.PERSEUS_CLIENT_ID,
        'perseus-session-id': process.env.PERSEUS_SESSION_ID,
        'Referer': process.env.REFERER,
        'Sec-Fetch-Dest': process.env.SEC_FETCH_DEST,
        'Sec-Fetch-Mode': process.env.SEC_FETCH_MODE,
        'Sec-Fetch-Site': process.env.SEC_FETCH_SITE,
        'TE': process.env.TE,
        'User-Agent': process.env.USER_AGENT,
        'X-FP-API-KEY': process.env.X_FP_API_KEY,
        'X-PD-Language-ID': process.env.X_PD_LANGUAGE_ID,
    };

    try {
        console.log(`Fetching data for restaurant ID: ${restaurantId}...`);
        const response = await axios.get<YemeksepetiVendorResponse>(url, {
            headers: headers as AxiosRequestHeaders,
        });

        if (response.status === 200) {
            return response.data;
        } else {
            console.error(`Unexpected status code: ${response.status}`);
            return null;
        }
    } catch (error: any) {
        if (axios.isAxiosError(error)) {
            console.error(`Error fetching data: ${error.message}`);
            if (error.response) {
                console.error(`Status: ${error.response.status}`);
                console.error(`Data:`, error.response.data);
            }
        } else {
            console.error(`An unexpected error occurred:`, error);
        }
        return null;
    }
}
