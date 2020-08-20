
/* global appChilquinta */
appConnect.service('httpService', function ($http)
{
    /**
     * cabecera de peticion por post
     * @param {type} route
     * @param {type} datas
     * @return {unresolved}
     */
    this.httpPost = function (route, datas)
    {
        return $http(
        {
            method: 'POST',
            type: 'text/json',
            url: route,
            data: datas
        });
    };

    /**
     * cabecera de peticion por get
     * @param {type} route
     * @return {unresolved}
     */
    this.httpGet = function (route)
    {
        return $http(
        {
            method: 'GET',
            type: 'text/json',
            url: route
        });
    };

});