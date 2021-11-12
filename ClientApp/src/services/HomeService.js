import http from './httpService';

const transApi = '/tran';
const yoyApi = '/tran/stpyoy';
const ffApi = '/tran/freshfund';
const mBalsApi = '/tran/ffmbals';
const custApi = '/customer';
const cardApi = '/card';
const balsApi = '/tran/ffbals';

function yoyUrl(id) {
  return `${yoyApi}/${id}`;
}

function usageUrl() {
  return `${cardApi}/usage`;
}

function custidUrl(id) {
  return `${custApi}/${id}`;
}

export function getTrans() {
  return http.get(transApi);
}

export function getTransYoy() {
  return http.get(yoyApi);
}

export function getTransYoyById(custId) {
  return http.get(yoyUrl(custId));
}

export function getCustomers() {
  return http.get(custApi);
}

export function getCustomer(id) {
  return http.get(custidUrl(id));
}

export function getCardStats() {
  return http.get(cardApi);
}

export function getCardUsage() {
  return http.get(usageUrl());
}

export function getFreshFund() {
  return http.get(ffApi);
}

export function getMbals() {
  return http.get(mBalsApi);
}

export function getBals() {
  return http.get(balsApi);
}
