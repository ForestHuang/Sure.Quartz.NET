(function () {
    toastr.options = { "closeButton": true, "debug": false, "progressBar": true, "positionClass": "toast-bottom-right", "onclick": null, "showDuration": "300", "hideDuration": "1000", "timeOut": "5000", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "fadeIn", "hideMethod": "fadeOut" };

    $("#uploadify").uploadify({
        uploader: '/QuartzManager/Upload', swf: '/Content/swf/uploadify.swf', queueID: 'some_file_queue', buttonText: '<i class="glyphicon glyphicon-upload"></i>', progressData: 'percentage', width: 47, removeCompleted: true, height: 25,
        auto: true, onQueueComplete: function (queueData) { if (queueData.uploadsSuccessful == 1) { toastr.success("上传成功"); } else { toastr.error("上传失败"); } }
    });

    //Vue.js MVVM
    var vm = new Vue({
        el: '#job-notdurable',
        data: {
            jobs: [],
            jobModel: null,
            QuartzJobModel: {
                jobName: '',
                jobGroupName: '',
                fullJobName: '',
                jobDescription: '',
                triggerName: '',
                triggerGroupName: '',
                cron: '',
                editcron: '',
                triggerDescription: ''
            }
        }, mounted: function () {
            getJobInfoList.bind(this)(1, 10);
        }, methods: {
            load: function () {
                $.get('/QuartzManager/LoadDurable', {}, function (data) {
                    vm.jobList = data;
                });
            }
            , addJob: function (event) {
                var formData = new FormData($('#job-form')[0]);
                $.ajax({
                    url: '/QuartzManager/AddJob', type: 'POST', data: formData, contentType: false, processData: false,
                    success: function (data) {
                        $('#modal-form').modal('hide');
                        toastr.success(data.Message);
                        vm.$options.methods.Load();
                    }
                })
            }
            , pauseJob: function (jobInfo) {
                $.post('/QuartzManager/PauseJob',
                    {
                        jobName: jobInfo.JobName,
                        jobGroupName: jobInfo.JobGroupName,
                        triggerName: jobInfo.TriggerName,
                        triggerGroupName: jobInfo.TriggerGroupName
                    }, function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("暂停成功");
                        } else { toastr.error("暂停失败"); }
                        vm.$options.methods.Load();
                    });
            }
            , resumeJob: function (jobInfo) {
                $.post('/QuartzManager/ResumeJob',
                    {
                        jobName: jobInfo.JobName,
                        jobGroupName: jobInfo.JobGroupName,
                        triggerName: jobInfo.TriggerName,
                        triggerGroupName: jobInfo.TriggerGroupName
                    }, function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("恢复成功");
                        } else { toastr.error("恢复失败"); }
                        vm.$options.methods.Load();
                    });
            }
            , deleteJob: function (jobInfo) {
                $.post('/QuartzManager/DeleteJob',
                    {
                        jobName: jobInfo.JobName,
                        jobGroupName: jobInfo.JobGroupName,
                        triggerName: jobInfo.TriggerName,
                        triggerGroupName: jobInfo.TriggerGroupName
                    }, function (data) {
                        if (data.StausCode == 'success') {
                            toastr.success("删除成功");
                        } else { toastr.error("删除失败"); }
                        vm.$options.methods.Load();
                    });
            }
            , editJob: function (jobInfo) {
                var formData = new FormData($('#job-editform')[0]);
                $.post('/QuartzManager/EditJob',
                    {
                        triggerName: jobInfo.TriggerName,
                        triggerGroupName: jobInfo.TriggerGroupName,
                        triggerCron: formData.get('jobEditCron')
                    }, function (data) {
                        if (data.StausCode == 'success') {
                            $('#modal-form').modal('hide');
                            toastr.success("修改成功");
                        } else { $('#modal-form').modal('hide'); toastr.error("修改失败"); }
                        vm.$options.methods.Load();
                    });
            }
        }
    });

    //Get JobList
    function getJobInfoList(pageIndex, pageSize) {
        var _self = this;
        $.get('/QuartzManager/LoadJobInfoData', {}, function (data) {
            _self.jobs = data;
        });
    }
    window.vm = vm;
})();