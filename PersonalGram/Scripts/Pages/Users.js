$('.delete-btn').click(function() {
    $.ajax({
        type: 'Post',
        url: '../User/DeleteUser',
        data: {
            id : +$(this).attr('data-id')
        },
        success: function(){
            location.reload()
        }, 
        error: function() {
            
        }
    })
})
