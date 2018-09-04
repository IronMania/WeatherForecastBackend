<template>
  <div>
   <forecast-hour v-bind:item="hour" v-bind:key="hour.id" v-for="(hour) in item.times"></forecast-hour>
   <br/>
  </div>
</template>

<script>
import ForecastHour from './ForecastHour.vue'


export default {
  name: 'ForecastDay',
  props: {
    item: Object,
  },
  components: {
    ForecastHour
  },
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
