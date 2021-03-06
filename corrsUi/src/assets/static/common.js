Date.prototype.getWeek = function() {
    var date = new Date(this.getTime())
    date.setHours(0, 0, 0, 0)
    date.setDate(date.getDate() + 3 - (date.getDay() + 6) % 7)
    var week1 = new Date(date.getFullYear(), 0, 4)
    return 1 + Math.round(((date.getTime() - week1.getTime()) / 86400000 - 3 + (week1.getDay() + 6) % 7) / 7)
}
  
function DateRangeOfWeek(weekNo, y){
    var d1, numOfdaysPastSinceLastMonday, rangeIsFrom, rangeIsT
    d1 = new Date(''+y+'');
    numOfdaysPastSinceLastMonday = d1.getDay() - 1
    d1.setDate(d1.getDate() - numOfdaysPastSinceLastMonday)
    d1.setDate(d1.getDate() + (7 * (weekNo - d1.getWeek())))
    rangeIsFrom = (d1.getMonth() + 1) + "/" + d1.getDate() + "/" + d1.getFullYear()
    d1.setDate(d1.getDate() + 6)
    rangeIsTo = (d1.getMonth() + 1) + "/" + d1.getDate() + "/" + d1.getFullYear()
    return rangeIsFrom + " to " + rangeIsTo
}

function GetWeekArr(result){
    var currentYearWeekNoArr = result[1]
    var lastYearWeekNoArr = 52 - result[1]
    var weekNo = []
    for (let i = 0; i < currentYearWeekNoArr; i++) {
      weekNo.push(
        {
          "value":i+1,
          "week": i+1,
          "year":result[0]
        }
      )
    }
    for (let e = 0; e < lastYearWeekNoArr; e++) {
      let cnt = e+1
      weekNo.push(
        {
          "value":cnt+currentYearWeekNoArr,
          "week": cnt+currentYearWeekNoArr,
          "year": result[0]-1
        }
      )
    }
    var range = []
    for (let j = 0; j < weekNo.length; j++) {
      range.push({
        "value": weekNo[j].week,
        "label": "W " + weekNo[j].week + ' - ' +DateRangeOfWeek(weekNo[j].week, weekNo[j].year)
      })
    }
    return range
}

function validateRowReasonSelect(i){
  var checkVal = document.getElementById('check'+i).checked
  return checkVal ? "Hit" : "Miss"
}
function validateRowCheck(i){
  return checkVal = document.getElementById('select'+i).value
}
function FilterData(data){
  var e = []
  for (let i = 0; i < data.length; i++) {
    var c = data[i].plantId
    e.push(c)
  }
  return e
}

function FilterPlantData(data){
  var e = []
  for (let i = 0; i < data.length; i++) {
    var c = data[i].plantDomain
    e.push(c)
  }
  return e
}
function DatePicker(){
  $("#weeklyDatePicker").datetimepicker({
    format: 'MM-DD-YYYY',
    minDate: moment().subtract(1, 'y'),
    maxDate: moment(),
    calendarWeeks: true,
    useCurrent: false
  })

  var newValDisp = ''
  $('#weeklyDatePicker').on('dp.hide', function (e) {
    $("#weeklyDatePicker").val(newValDisp)
  })

  $('#weeklyDatePicker').on('dp.change', function (e) {
    value = $("#weeklyDatePicker").val();
    firstDate = moment(value, "MM-DD-YYYY").day(0).format("MM-DD-YYYY");
    lastDate =  moment(value, "MM-DD-YYYY").day(6).format("MM-DD-YYYY");
    firstDate = firstDate.split('-')
    lastDate = lastDate.split('-')
    var week = e.date.week() || ''
    var endYear = lastDate[2] || ''
    var endMonth = lastDate[1] || ''
    var startdate = firstDate[0] || ''
    var endDate = lastDate[0] || ''
    var startMonth = firstDate[0] || ''
    var startYear = firstDate[2] || ''
    newValDisp = 'W'+week+' ('+startMonth+'/'+startdate+'/'+startYear+'-'+endMonth+'/'+endDate+'/'+endYear+')'
    $("#weeklyDatePicker").val(newValDisp)
    $("#weeklyDatePickerHidden").val(week)
    $('#hideErr').hide()
    $("#weeklyDatePicker").removeClass('error')
  })
}

function GetWeek(){
  return $("#weeklyDatePickerHidden").val()
}

function GetWeekLabel(){
  return $("#weeklyDatePicker").val()
}