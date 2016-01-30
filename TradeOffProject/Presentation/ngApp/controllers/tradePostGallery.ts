namespace TradeOffProject.Controllers {

    export class TradePostGalleryController {

        public tradePosts;
        public categories;

        constructor(private $http: ng.IHttpService) {
            this.GetCategories();
            $http.get('/api/tradePosts')
                .then((response) => {
                    this.tradePosts = response.data;
                });
        }

        public GetCategories() {
            this.$http.get('/api/categories')
                .then((response) => {
                    this.categories = response.data;
                });
        }
    }
}