const API_BASE_URL_DEVELOPMENT = "https://localhost:7254";

const ENDPOINTS = {
    GET_ALL_CRYPTOS: 'get-all-cryptos',
    GET_CRYPTOS_BY_ID: 'get-crypto-by-id',
    CREATE_CRYPTO: 'create-crypto',
    UPDATE_CRYPTO: 'update-crypto',
    DELETE_POST_BY_ID: 'delete-crypto-by-id'
};

const development = {
    API_URL_GET_ALL_CRYPTOSn: `${ENDPOINTS.GET_ALL_CRYPTOS}`,
    API_URL_GET_CRYPTO_BY_ID: `${ENDPOINTS.GET_CRYPTOS_BY_ID}`,
    API_URL_CREATE_CRYPTO: `${ENDPOINTS.CREATE_CRYPTO}`,
    API_URL_UPDATE_CRYPTO: `${ENDPOINTS.UPDATE_CRYPTO}`,
    API_URL_DELETE_POST_BY_ID: `${ENDPOINTS.DELETE_POST_BY_ID}`
};

const Constants = process.env.NODE_ENV === 'development' ? development: null;

export default Constants;
