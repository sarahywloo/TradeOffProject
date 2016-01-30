namespace TradeOffProject.Controllers {

    export class AddPostsController {

        public tradePost;

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) { }

        public addTradePost(tradePost): void {
            this.$http.post('/api/gallery/addpost', tradePost)
                .then((response) => {
                    this.$location.path('/gallery');
                })
                .catch((response) => {
                    console.log(response);
                });
        }
    }
}