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
            isShowRun: true,
            isShowPause: true,
            isShowResume: true,
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
            getJobInfoList.bind(this)(1, 100);
        }, methods: {
            Load: function () {
                $.get('/QuartzManager/LoadDurable', {}, function (data) {
                    vm.jobList = data;
                });
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
                        vm.$options.methods.Load();
                    }
                })
            }
            , runJob: function (jobInfo) {
                jobInfo.State = 0;
                jobInfo.Deleted = false;
                $.ajax({
                    url: '/QuartzManager/RunJobDurable', type: 'POST', data: { jobs: JSON.stringify(jobInfo) },
                    success: function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("运行成功");
                        } else { toastr.error("运行失败"); }
                        vm.$options.methods.Load();
                    }
                })
            }
            , pauseJob: function (jobInfo) {
                jobInfo.State = 0;
                jobInfo.Deleted = false;
                $.ajax({
                    url: '/QuartzManager/PauseJobDurable', type: 'POST', data: { jobs: JSON.stringify(jobInfo) },
                    success: function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("暂停成功");
                        } else { toastr.error("暂停失败"); }
                        vm.$options.methods.Load();
                    }
                })
            }
            , resumeJob: function (jobInfo) {
                jobInfo.State = 0;
                jobInfo.Deleted = false;
                $.ajax({
                    url: '/QuartzManager/ResumeJobDurable', type: 'POST', data: { jobs: JSON.stringify(jobInfo) },
                    success: function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("恢复成功");
                        } else { toastr.error("恢复失败"); }
                        vm.$options.methods.Load();
                    }
                })
            }
            , deleteJob: function (jobInfo) {
                jobInfo.State = 0;
                jobInfo.Deleted = false;
                $.ajax({
                    url: '/QuartzManager/ResumeJobDurable', type: 'POST', data: { jobs: JSON.stringify(jobInfo) },
                    success: function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("删除成功");
                        } else { toastr.error("删除失败"); }
                        vm.$options.methods.Load();
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