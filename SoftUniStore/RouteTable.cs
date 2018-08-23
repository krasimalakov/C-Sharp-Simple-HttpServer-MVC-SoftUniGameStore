namespace SoftUniStore
{
    using System.Collections.Generic;
    using System.IO;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;

    public static class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new[]
                {
                    // routes for resources
                    new Route
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "^.*/js/bootstrap.min.js$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../Content{request.Url}"),
                                Header = { ContentType = "application/x-javascript" }
                            };
                            return response;
                        }
                    },

                     new Route()
                    {
                         Name = "Jquery",
                         Method = RequestMethod.GET,
                         UrlRegex = @"^/scripts/jquery.+\.js$",
                         Callable = (request) =>
                         {
                             var response = new HttpResponse
                             {
                                 StatusCode = ResponseStatusCode.Ok,
                                 ContentAsUTF8 = File.ReadAllText($"../../Content{request.Url}"),
                                 Header = { ContentType = "application/x-javascript" }
                             };
                             return response;
                        }
                    },
                    new Route
                    {
                        Name = "Bootstrap CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = "^/css/bootstrap.min.css$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../Content{request.Url}"),
                                Header = { ContentType = "text/css" }
                            };
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Bootstrap CSS Map",
                        Method = RequestMethod.GET,
                        UrlRegex = "^/css/bootstrap.min.css.map$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../Content{request.Url}"),
                                Header = { ContentType = "text/html" }
                            };
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Custom CSS's",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/css/.+\.css$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 =
                                    File.ReadAllText($"../../Content{request.Url}"),
                                Header = { ContentType = "text/css" }
                            };
                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Images",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/images/.+$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content =
                                    File.ReadAllBytes($"../../Content{request.Url}"),
                                Header = { ContentType = "image/*" }
                            };

                            return response;
                        }
                    },
                    new Route
                    {
                        Name = "Favicon.ico",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/\.*favicon.ico$",
                        Callable = request =>
                        {
                            var response = new HttpResponse
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content =
                                    File.ReadAllBytes($"../../Content{request.Url}"),
                                Header = { ContentType = "image/x-icon" }
                            };

                            return response;
                        }
                    },
                    //routes for actions 
                    new Route
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable = new ControllerRouter().Handle
                    },
                     new Route
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}