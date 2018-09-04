<template>
  <div>
        <b-card v-bind:title="item.time | convertHour">
        Windspeed: {{item.windSpeed }} meter/sec  <br/>
        Temperature:{{ item.temperature}} &deg;Celsius<br/>       
        Humidity: {{item.humidity}} %  <br/>    
    </b-card>
   
    
  </div>
</template>

<script>
import moment from 'moment'

export default {
  name: 'ForecastHour',
  props: {
    item: Object
  },
      filters: {
  convertHour: function (value) {
    if (!value) return ''
    return moment(value).format("hA");
  }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
