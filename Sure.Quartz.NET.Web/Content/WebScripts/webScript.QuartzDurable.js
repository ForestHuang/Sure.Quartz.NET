$(function () {
    $("#datetimepicker-start").datetimepicker({ format: 'yyyy-mm-dd hh:ii', language: 'zh-CN', pickerPosition: 'top-right' });

    $("#datetimepicker-end").datetimepicker({ format: 'yyyy-mm-dd hh:ii', language: 'zh-CN', pickerPosition: 'top-right' });
});

(function () {
    toastr.options = { "closeButton": true, "debug": false, "progressBar": true, "positionClass": "toast-bottom-right", "onclick": null, "showDuration": "300", "hideDuration": "1000", "timeOut": "5000", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "fadeIn", "hideMethod": "fadeOut" };

    $("#uploadify").uploadify({
        uploader: '/QuartzManager/Upload', swf: '/Content/swf/uploadify.swf', queueID: 'some_file_queue', buttonText: '<i class="glyphicon glyphicon-upload"></i>', progressData: 'percentage', width: 47, removeCompleted: true, height: 25,
        auto: true, onQueueComplete: function (queueData) { if (queueData.uploadsSuccessful == 1) { toastr.success("上传成功"); } else { toastr.error("上传失败"); } }
    });

    //Vue.js MVVM
    var vm = new Vue({
        el: '#job-durable',
        data: {
            jobList: [],
            jobModel: null,
            //JobInfo
            jobName: '',
            jobGroupName: '',
            triggerName: '',
            triggerGroupName: '',
            fullJobName: '',
            description: '',
            cron: '',
            requestUrl: ''
        }, mounted: function () {
            getJobInfoList.bind(this)(1, 10);
        }, methods: {
            loadGetJob: function () {
                getJobInfoList.bind(this)(1, 10);
            }
            , addJob: function (event) {
                var formData = {
                    JobName: this.jobName,
                    JobGroupName: this.jobGroupName,
                    TriggerName: this.triggerName,
                    TriggerGroupName: this.triggerGroupName,
                    Cron: this.cron,
                    StartTime: $("#datetimepicker-start").data("datetimepicker").getDate(),
                    EndTime: $("#datetimepicker-end").data("datetimepicker").getDate(),
                    Description: this.description,
                    FullJobName: this.fullJobName,
                    RequestUrl: this.requestUrl
                };
                $.ajax({
                    url: '/QuartzManager/AddDurable', type: 'POST', data: { jobs: JSON.stringify(formData) },
                    success: function (data) {
                        $('#modal-form-Durable').modal('hide');
                        toastr.success(data.Message);
                        //$('#nav-jobStatus li[data-jobStatus=-1]').click();
                    }
                })
            }
        }
    });

    //Get JobList
    function getJobInfoList(pageIndex, pageSize) {
        var _self = this;
        $.get('/QuartzManager/LoadDurable', {}, function (data) {
            _self.jobList = data;
        });
    }
    window.vm = vm;
})();