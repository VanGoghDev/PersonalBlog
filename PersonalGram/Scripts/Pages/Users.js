var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!'
    },
    methods: {
        deleteUser: function(id) {
            $.ajax({
                type: 'Post',
                url: '../User/DeleteUser',
                data: {
                    id : +id
                },
                success: function(){
                    location.reload()
                },
                error: function() {

                }
            })
        }
    }
})
