<template>
  <div id="Search">
    Search:
    <input v-model="city" type="text"  placeholder="City or Postal Code in Germany">
    <ul v-if="searchResults.length > 0">
            <li v-for="result in searchResults" :key="result.id" v-text="result"></li>
    </ul>
    <button v-on:click="SearchWeather(city)" >Search</button>
    <br/>
    <forecast-day 
      v-for="(item,index) in request.forecastsPerDay"
      v-bind:item="item"
      v-bind:index="index"
      v-bind:key="item.id"
     ></forecast-day>
  </div>
</template>

<script>
import axios from 'axios'
import ForecastDay from './ForecastDay.vue'
export default {
  name: 'Search',
    components: {
    ForecastDay
  },
  data(){
    return{
      city : '',
      request: '',
      searchResults: [],
      SearchWeather: function (city) {
      // `this` inside methods points to the Vue instance
      axios
        .get('https://localhost:44319/api/weather/forecast?city='+city)
        .then(response => (this.request = response.data))
      //https://localhost:44319/api/weather/forecast?city=blubb
    }
    }
  },
  watch: {
      city() {
        this.fetch();
      }
  },
  methods: {
    fetch() {
        axios.get('https://localhost:44319/api/weather/history', { params: { city: this.city } })
            .then(response => this.searchResults = response.data.searchResults);
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
