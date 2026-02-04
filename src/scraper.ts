import axios from 'axios';
import type { AxiosRequestHeaders } from 'axios';
import * as dotenv from 'dotenv';
import type { YemeksepetiVendorResponse, AutocompleteResponse, GraphQLResponse } from './models.js';

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

export async function fetchAutocomplete(lat: number, lng: number): Promise<AutocompleteResponse | null> {
    const url = 'https://disco.deliveryhero.io/search/api/v3/autocomplete';

    const headers: any = {
        'Accept': 'application/json, text/plain, */*',
        'Accept-Encoding': 'gzip, deflate, br, zstd',
        'Accept-Language': 'en-US,en;q=0.9',
        'Content-Type': 'application/json;charset=utf-8',
        'Origin': 'https://www.yemeksepeti.com',
        'Referer': 'https://www.yemeksepeti.com/',
        'User-Agent': process.env.USER_AGENT || 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:147.0) Gecko/20100101 Firefox/147.0',
        'perseus-client-id': process.env.PERSEUS_CLIENT_ID,
        'perseus-session-id': process.env.PERSEUS_SESSION_ID,
        'dps-session-id': process.env.DPS_SESSION_ID,
        'Sec-Fetch-Dest': 'empty',
        'Sec-Fetch-Mode': 'cors',
        'Sec-Fetch-Site': 'cross-site',
    };

    const data = {
        "query": "",
        "brand": "yemeksepeti",
        "country_code": "tr",
        "language_id": "2",
        "customer_id": "",
        "location": {
            "point": {
                "latitude": lat,
                "longitude": lng
            }
        },
        "opening_type": "delivery",
        "vertical_types": ["restaurants"],
        "use_free_delivery_label": true,
        "tag_label_metadata": false
    };

    try {
        console.log(`Fetching autocomplete for Lat: ${lat}, Lng: ${lng}...`);
        const response = await axios.post<AutocompleteResponse>(url, data, {
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
            console.error(`Error fetching autocomplete: ${error.message}`);
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

export async function fetchGraphQLData(lat: number, lng: number): Promise<GraphQLResponse | null> {
    const url = 'https://tr.fd-api.com/graphql';

    const headers: any = {
        'Accept': 'application/json, text/plain, */*',
        'Accept-Encoding': 'gzip, deflate, br, zstd',
        'Accept-Language': 'en-US,en;q=0.9',
        'Content-Type': 'application/json;charset=utf-8',
        'User-Agent': process.env.USER_AGENT || 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:147.0) Gecko/20100101 Firefox/147.0',
        'perseus-client-id': process.env.PERSEUS_CLIENT_ID,
        'perseus-session-id': process.env.PERSEUS_SESSION_ID,
        'dps-session-id': process.env.DPS_SESSION_ID,
        'Platform': 'web',
        'App-Version': 'VENDOR-LIST-MICROFRONTEND.26.04.0006',
        'X-FP-API-KEY': 'volo',
        'Customer-Latitude': lat.toString(),
        'Customer-Longitude': lng.toString(),
        'Display-Context': 'rlp',
        'locale': 'tr_TR',
        'apollographql-client-name': 'web',
        'apollographql-client-version': 'VENDOR-LIST-MICROFRONTEND.26.04.0006',
        'Origin': 'https://www.yemeksepeti.com',
        'Referer': 'https://www.yemeksepeti.com/',
        'Sec-Fetch-Dest': 'empty',
        'Sec-Fetch-Mode': 'cors',
        'Sec-Fetch-Site': 'cross-site',
    };

    const payload = {
        "extensions": {
            "persistedQuery": {
                "sha256Hash": "71df256e1a0d7a7df73b0b60a69b9e2a19c2fdc8e17b6e9543dcd64101271cbf",
                "version": 1
            }
        },
        "variables": {
            "input": {
                "expeditionType": "DELIVERY",
                "latitude": lat,
                "locale": "tr_TR",
                "longitude": lng,
                "customerType": "B2C",
                "featureFlags": [
                    { "name": "dynamic-pricing-indicator", "value": "Original" },
                    { "name": "saver-delivery-upper-funnel", "value": "Control" },
                    { "name": "pd-mp-homescreen-full-federation-listing", "value": "Control" },
                    { "name": "vdp_citadel-tech-integration", "value": "Control" },
                    { "name": "pd-mp-slp-replatform-federated", "value": "Control" }
                ],
                "languageId": 2,
                "page": "RESTAURANT_LANDING_PAGE"
            }
        }
    };

    try {
        console.log(`Fetching GraphQL restaurants for Lat: ${lat}, Lng: ${lng}...`);
        const response = await axios.post<GraphQLResponse>(url, payload, {
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
            console.error(`Error fetching GraphQL data: ${error.message}`);
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
