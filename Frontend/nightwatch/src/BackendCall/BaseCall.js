export default class BaseCall {

    static Get(route) {
        return fetch("https://localhost:7293" + route, { method: "GET" });
    }
    static Put(route) {

        return fetch("https://localhost:7293" + route, { method: "PUT" });
    }
    static Post(route, body = {}) {

        return fetch("https://localhost:7293" + route, { method: "POST", body: JSON.stringify(body), headers: new Headers({ 'content-type': 'application/json' }) });
    }

    static Delete(route) {

        return fetch("https://localhost:7293" + route, { method: "DELETE" });
    }

}